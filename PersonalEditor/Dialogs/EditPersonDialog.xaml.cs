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
using STW.UNSK.Personal.Model;

namespace PersonalEditor.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для EditPersonDialog.xaml
    /// </summary>
    public partial class EditPersonDialog : Window
    {
        public EditPersonDialog(Person person, List<Post> avaliablePosts)
        {
            InitializeComponent();
            PersonEditorVM PersonEditorVM = PersonEditorVMFactory.Generate(person, avaliablePosts);
            personEditor.DataContext = PersonEditorVM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
