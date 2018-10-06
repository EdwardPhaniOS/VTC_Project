using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LaborLawHandBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Frame_NoiDung.Navigate(typeof(Page_QAView));
        }

        private void btHome_Click(object sender, RoutedEventArgs e)
        {
            splitview.IsPaneOpen = !splitview.IsPaneOpen;
        }

        private void btThem_Click(object sender, RoutedEventArgs e)
        {
            Frame_NoiDung.Navigate(typeof(AddToQAList));
        }

        private void btSua_Click(object sender, RoutedEventArgs e)
        {
            Frame_NoiDung.Navigate(typeof(EditQAList));
        }
            

        private void btLuuVaoDanhSach_Click(object sender, RoutedEventArgs e)
        {
            Frame_NoiDung.Navigate(typeof(AddToFavorite));
        }

        private void btDanhSach_Click(object sender, RoutedEventArgs e)
        {
            Frame_NoiDung.Navigate(typeof(Page_FavoriteView));
        }

        private void btXoaKhoiDanhSach_Click(object sender, RoutedEventArgs e)
        {
            Frame_NoiDung.Navigate(typeof(RemoveFromFavorite));
        }

        private void btQuayVe_Click(object sender, RoutedEventArgs e)
        {
            Frame_NoiDung.Navigate(typeof(Page_QAView));
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            CreateQAList.listResult.Clear();
            string timKiem = Timkiem.Text.ToLower();
            foreach (QuestionAndAnswer QA in CreateQAList.listQA)
            {
                if (QA.dap_an.ToLower().Contains(timKiem) || QA.cau_hoi.ToLower().Contains(timKiem))
                {
                    CreateQAList.listResult.Add(QA);
                }

            }
            Frame_NoiDung.Navigate(typeof(Page_Result));
        }
    }
}
