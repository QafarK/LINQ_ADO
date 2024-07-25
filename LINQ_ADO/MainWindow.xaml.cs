using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LINQ_ADO;

public partial class MainWindow : Window, INotifyPropertyChanged
{
    string? CB1;
    ObservableCollection<dynamic>? cb2;
    ObservableCollection<string>? listView;

    public ObservableCollection<dynamic>? CB2ITEMS { get => cb2; set { cb2 = value; OnPropertyChanged(); } }
    public ObservableCollection<string>? List_View { get => listView; set { listView = value; OnPropertyChanged(); } }

    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        CB2ITEMS = new();

        ComboBox? comboBox = sender as ComboBox;
        if (comboBox is not null && comboBox.SelectedValue is not null)
            CB1 = comboBox.SelectedItem.ToString().Split(' ')[1];

        if (CB1 is not null)
        {
            using (LibraryContext db = new())
            {
                if (CB1.Equals("Authors"))
                {
                    var datas = db.Authors.ToList();
                    if (datas is not null)
                        datas.ForEach(d => CB2ITEMS.Add(d.ToString()));

                }
                else if (CB1.Equals("Themes"))
                {
                    var datas = db.Themes.ToList();
                    if (datas is not null)
                        datas.ForEach(d => CB2ITEMS.Add(d.ToString()));
                }
                else if (CB1.Equals("Categories"))
                {
                    var datas = db.Categories.ToList();
                    if (datas is not null)
                        datas.ForEach(d => CB2ITEMS.Add(d.ToString()));
                }
            }
        }
        List_View = null;
    }

    private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {
        List_View = new();
        ComboBox? comboBox = sender as ComboBox;
        string? cb2item = "";


        if (comboBox is not null && comboBox.SelectedValue is not null)
            cb2item = comboBox.SelectedItem.ToString();

        using (LibraryContext db = new())
        {
            if (CB1.Equals("Authors"))
            {
                var item = cb2item.Replace(" ", "");
                var books = db.Books.Join(db.Authors, b => b.Id_Author, a => a.Id,
                    (b, a) => new
                    {
                        Name = b.Name,
                        AuthorFirstName = a.FirstName,
                        AuthorLastName = a.LastName,

                    }).Where(x => (x.AuthorFirstName + x.AuthorLastName).Replace(" ", "").Equals(item)).ToList();

                books.ForEach(b => List_View.Add(b.Name));
            }
            else if (CB1.Equals("Themes"))
            {
                var books = db.Books.Join(db.Themes, b => b.Id_Themes, t => t.Id,
                    (b, t) => new
                    {
                        Name = b.Name,
                        ThemeName = t.Name,
                    }).Where(x => x.ThemeName.Equals(cb2item)).ToList();

                books.ForEach(b => List_View.Add(b.Name));
            }
            else if (CB1.Equals("Categories"))
            {
                var books = db.Books.Join(db.Categories, b => b.Id_Category, c => c.Id,
                    (b, c) => new
                    {
                        Name = b.Name,
                        CategoryName = c.Name,
                    }).Where(x => x.CategoryName.Equals(cb2item)).ToList();

                books.ForEach(b => List_View.Add(b.Name));
            }
        }

    }


    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}