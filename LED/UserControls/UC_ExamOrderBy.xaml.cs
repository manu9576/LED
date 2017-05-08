using System;
using System.Collections.Generic;
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
using LED.Models;

namespace LED.UserControls
{
    /// <summary>
    /// Logique d'interaction pour UC_ExamOrderBy.xaml
    /// </summary>
    public partial class UC_ExamOrderBy : UserControl, IUC_Exam
    {
        private const string COPY_PASTE = "CP_TB";

        ViewExamOrderBy m_view = null;
        Point m_StartPoint;


        public UC_ExamOrderBy()
        {
            InitializeComponent();
        }

        public UC_ExamOrderBy(List<ItemOrderBy> questions)
        {
            InitializeComponent();

            m_view = new ViewExamOrderBy(questions);

            List<string> items = new List<string>();

            foreach (ItemOrderBy question in questions)
            {
                GroupBox gb = new GroupBox()
                {
                    AllowDrop = true,
                    Header = question.Contenaire
                };

                ListView lv = new ListView()
                {
                    BorderBrush = null
                };
                gb.Content = lv;

                lv.Drop += DropTextBox;
                lv.DragEnter += DragEnterTextBox;

                uc_sp_contenaires.Children.Add(gb);

                items.AddRange(question.Items.Split(';'));
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

                tb.PreviewMouseLeftButtonDown += SelectTextBox;
                tb.PreviewMouseMove += MoveTextBox;
                uc_lv_items.Items.Add(tb);
            }
        }

        #region Drag&Drop
        private void DropTextBox(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(COPY_PASTE) && e.Data.GetData(COPY_PASTE) is Label)
            {
                Label tb = e.Data.GetData(COPY_PASTE) as Label;

                if (tb.Parent is ListView && sender is ListView)
                {
                    (tb.Parent as ListView).Items.Remove(tb);
                    ListView lv = sender as ListView;
                    lv.Items.Add(tb);
                }
            }
        }

        private void DragEnterTextBox(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(COPY_PASTE) || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MoveTextBox(object sender, MouseEventArgs e)
        {
            // Get the current mouse position
            Point mousePos = e.GetPosition(null);
            Vector diff = m_StartPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed && sender is Label &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject(COPY_PASTE, sender as Label);
                DragDrop.DoDragDrop((sender as Label).Parent, dragData, DragDropEffects.Move);
            }
        }

        private void SelectTextBox(object sender, MouseButtonEventArgs e)
        {
            // Store the mouse position
            m_StartPoint = e.GetPosition(null);
        }
        #endregion

        private void Uc_sp_contenaires_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double sizeGroupBox = uc_gb_Contenaires.ActualHeight / m_view.Contenaires.Count;

            foreach (Control gb in uc_sp_contenaires.Children)
            {
                if (gb is GroupBox && (gb as GroupBox).Content is ListView)
                {
                    ((gb as GroupBox).Content as ListView).Height = sizeGroupBox;

                }
                gb.Height = sizeGroupBox;
            }

        }

        public bool Validate()
        {
            m_view.Answers = new List<ItemOrderBy>();

            foreach(GroupBox gb in uc_sp_contenaires.Children)
            {
                List<string> items = new List<string>();

                if(gb.Content is ListView )
                {
                    ListView lv = gb.Content as ListView;

                    

                    foreach(Label lb in lv.Items)
                    {
                        if(lb != null)
                        {
                            items.Add(lb.Content as string);
                        }
                    }
                }

                m_view.Answers.Add(new ItemOrderBy { Contenaire = gb.Header as string, Items = string.Join(";", items) });

            }

            return m_view.Validate();
        }
    }
}
