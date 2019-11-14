using STW.UNSK.Personal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonalEditor.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddPersonDialog : Window,IAddPersonDialog
    {
        
        public AddPersonDialog(Person person,ICollection<Post> avaliablePosts )
        {
            InitializeComponent();
            Person = person;
            var personEditorVM = PersonEditorVMFactory.Generate(person, avaliablePosts);
            personEditor.DataContext = personEditorVM;
        }

        public Person Person { get; internal set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
