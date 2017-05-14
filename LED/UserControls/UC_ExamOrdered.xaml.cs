using LED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace LED.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UC_ExamOrdered.xaml
    /// </summary>
    public partial class UC_ExamOrdered : UserControl, IUC_Exam
    {
        private const string COPY_PASTE = "CP_TB";

        ViewExamOrdered m_view = null;

        public UC_ExamOrdered()
        {
            InitializeComponent();
        }

        public UC_ExamOrdered(List<ItemOrdered> questions)
        {
            InitializeComponent();

            m_view = new ViewExamOrdered(questions);
            List<string> items = new List<string>();


            foreach (ItemOrdered item in questions)
            {
                items.Add(item.Name);
            }

            Randomizer.Randomize(items);

            foreach (string item in items)
            {

                Label tb = new Label()
                {
                    Content = item,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                };

                tb.PreviewMouseLeftButtonDown += DragEnterTextBox;
                tb.Drop += SelectTextBox;
                tb.AllowDrop = true;

                UC_lv_Items.Items.Add(tb);

            }
        }

        private void SelectTextBox(object sender, DragEventArgs e)
        {
         
            if (e.Data.GetDataPresent(COPY_PASTE) && e.Data.GetData(COPY_PASTE) is Label)
            {
                Label droppedData = e.Data.GetData(COPY_PASTE) as Label;
                Label target = e.Source as Label;

                if(droppedData != target)
                {
                    int targetIdx = UC_lv_Items.Items.IndexOf(target);


                    UC_lv_Items.Items.Remove(droppedData);

                UC_lv_Items.Items.Insert(targetIdx, droppedData);

                }
            }

        }

        private void DragEnterTextBox(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is Label)
            {
                // Initialize the drag & drop operation
                DataObject dragData = new DataObject(COPY_PASTE, sender as Label);
                Label draggedItem = e.Source as Label;
                DragDrop.DoDragDrop(draggedItem, dragData, DragDropEffects.Move);
            }
        }

        public bool Validate()
        {
            m_view.Answers = new List<ItemOrdered>();

            foreach(Label lb in UC_lv_Items.Items)
            {
                if(lb!= null)
                {
                    m_view.Answers.Add(new ItemOrdered { Name = lb.Content as string, Place = UC_lv_Items.Items.IndexOf(lb) });
                }
            }

            return m_view.Validate();

        }

        public void Enabled(bool etat)
        {
            if (this.Dispatcher.Thread != Thread.CurrentThread)
                Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() => Enabled(etat)));
            else
                IsEnabled = etat;
        }
    }

}
