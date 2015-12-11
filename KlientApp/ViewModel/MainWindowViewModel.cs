using KlientApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KlientApp.ViewModel
{
    public class MainWindowViewModel : ObservableObject
    {

        public MainWindowViewModel()
        {
            ListOfContacts = new ObservableCollection<Contact>();

            using (var ctx = new KlientContext())
            {
                MyCommand = new SimpleRelayCommand(fun);


                Contact con = new Contact { NickName = "elo ! " };
                UserOfApplication uoa = new UserOfApplication { Password = "aaaa", Login = "aaaa" };
                ctx.UserOfApplications.Add(uoa);
                ctx.Contacts.Add(con);
                ctx.SaveChanges();

                var persons = from c in ctx.Contacts select c;

                foreach(var item in persons)
                {
                    ListOfContacts.Add(item);
                }

            }
        }
        private ObservableCollection<Contact> listOfContacts;

        public ObservableCollection<Contact> ListOfContacts
        {
            get { return listOfContacts; }

            set
            {
                listOfContacts = value;
                OnPropertyChanged("ListOfContacts");
            }
        }

        public void fun()
        {
            Thread newWindowThread = new Thread(new ThreadStart(() =>
            {
                // Create and show the Window
                System.Windows.MessageBox.Show("heheheehehe");
                // Start the Dispatcher Processing
                System.Windows.Threading.Dispatcher.Run();
            }));

            // Set the apartment state
            newWindowThread.SetApartmentState(ApartmentState.STA);
            // Make the thread a background thread
            newWindowThread.IsBackground = true;
            // Start the thread
            newWindowThread.Start();
            
        }

        private ICommand myCommand;
        public ICommand MyCommand
        {

            get
            {
                return myCommand;
            }
            set
            {
                myCommand = value;
                OnPropertyChanged("MyCommand");
            }
        }
    }
}
