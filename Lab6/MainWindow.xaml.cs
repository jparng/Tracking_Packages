using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<Packages> packageList = new List<Packages>();
        int index = 0;
 

        private void scanClick(object sender, RoutedEventArgs e)
        {
            Random num = new Random();
            DateTime arrived = DateTime.Now;
            arriveBox.Text = arrived.ToString();
            int packNumber = num.Next(1000,9999);
            packageBox.Text = packNumber.ToString();
            addressBox.IsEnabled = true;
            cityBox.IsEnabled = true;
            stateBox.IsEnabled = true;
            zipBox.IsEnabled = true;
            packageStatebox.IsEnabled = true;
            editBtn.IsEnabled = false;
            removeBtn.IsEnabled = false;
            addBtn.IsEnabled = true;
            stateBox.Text = "";
            addressBox.Text = "";
            cityBox.Text = "";
            zipBox.Text = "";
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            if(stateBox.Text == "")
            {
                MessageBox.Show("Please enter a state.");
            }
            else
            {
                try
                {
                    packageList.Add(new Packages { Address = addressBox.Text, City = cityBox.Text, State = stateBox.Text, PackageID = Int32.Parse(packageBox.Text), ZipCode = Int32.Parse(zipBox.Text), Time = arriveBox.Text });
                    removeBtn.IsEnabled = true;
                    backBtn.IsEnabled = true;
                    editBtn.IsEnabled = true;
                    addBtn.IsEnabled = false;
                }
                catch (FormatException)
                {
                    MessageBox.Show("Please enter the proper address.");
                }
            }




        }


        private void deleteBtn(object sender, RoutedEventArgs e)
        {   index = packageList.FindIndex(x => x.PackageID.ToString() == packageBox.Text);
            int prev = index - 1;
            int next = index + 1;
            if (index - 1 > -1)
            {
                packageList.RemoveAt(index);
                addressBox.Text = packageList[prev].Address.ToString();
                cityBox.Text = packageList[prev].City.ToString();
                stateBox.Text = packageList[prev].State.ToString();
                packageBox.Text = packageList[prev].PackageID.ToString();
                zipBox.Text = packageList[prev].ZipCode.ToString();
                arriveBox.Text = packageList[prev].Time.ToString();
            }
            else if(index == 0)
            {
                packageList.RemoveAt(0);
                addressBox.Text = "";
                cityBox.Text = "";
                stateBox.Text = "";
                packageBox.Text = "";
                zipBox.Text = "";
                arriveBox.Text = "";
                backBtn.IsEnabled = false;
               
            }
            else if(packageList.Count == 0)
            {
                addressBox.Text = "";
                cityBox.Text = "";
                stateBox.Text = "";
                packageBox.Text = "";
                zipBox.Text = "";
                arriveBox.Text = "";
                removeBtn.IsEnabled = false;
                editBtn.IsEnabled = false;
                nextBtn.IsEnabled = false;
            }

        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            index = packageList.FindIndex(x => x.PackageID.ToString() == packageBox.Text);
            int prev = index - 1;
            if(index - 1 > -1)
            {
                addressBox.Text = packageList[prev].Address.ToString();
                cityBox.Text = packageList[prev].City.ToString();
                stateBox.Text = packageList[prev].State.ToString();
                packageBox.Text = packageList[prev].PackageID.ToString();
                zipBox.Text = packageList[prev].ZipCode.ToString();
                arriveBox.Text = packageList[prev].Time.ToString();
                nextBtn.IsEnabled = true;
            }
            else
            {
                backBtn.IsEnabled = false;
            }

        }

        private void goNext(object sender, RoutedEventArgs e)
        {
            index = packageList.FindIndex(x => x.PackageID.ToString() == packageBox.Text);
            int next = index + 1;
            int listLength = packageList.Count;
            if (next < listLength)
            {
                addressBox.Text = packageList[next].Address.ToString();
                cityBox.Text = packageList[next].City.ToString();
                stateBox.Text = packageList[next].State.ToString();
                packageBox.Text = packageList[next].PackageID.ToString();
                zipBox.Text = packageList[next].ZipCode.ToString();
                arriveBox.Text = packageList[next].Time.ToString();
                backBtn.IsEnabled = true;
            }
            else
            {
                nextBtn.IsEnabled = false;
            }

            
        }

        private void editItems(object sender, RoutedEventArgs e)
        {
            try
            {
                index = packageList.FindIndex(x => x.PackageID.ToString() == packageBox.Text);
                packageList[index] = new Packages() { Address = addressBox.Text, City = cityBox.Text, State = stateBox.Text, PackageID = Int32.Parse(packageBox.Text), ZipCode = Int32.Parse(zipBox.Text), Time = arriveBox.Text};
                MessageBox.Show($"Package has been edited");
            }
            catch(FormatException)
            {
                MessageBox.Show("Please enter all address information to edit.");
            }
           
        }

        private void stateSelect(object sender, SelectionChangedEventArgs e)
        {
            stateList.Items.Clear();
            foreach (var packages in packageList)
            {
                if (packageStatebox.Text == packages.State)
                {
                    stateList.Items.Add(packages.PackageID.ToString());
                }
            }
        }

        private void stateSelected(object sender, EventArgs e)
        {
            stateList.Items.Clear();
            foreach (var packages in packageList)
            {
                if (packageStatebox.Text == packages.State)
                {
                    stateList.Items.Add(packages.PackageID.ToString());
                }
            }
        }
    }
}
