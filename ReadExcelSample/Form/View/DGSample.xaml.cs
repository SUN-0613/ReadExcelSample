using System.Windows;

namespace ReadExcelSample.Form.View
{
    /// <summary>
    /// DGSample.xaml の相互作用ロジック
    /// </summary>
    public partial class DGSample : Window
    {

        private ViewModel.DGSample _ViewModel;

        /// <summary>
        /// DGSample.View
        /// </summary>
        public DGSample()
        {

            InitializeComponent();

            _ViewModel = new ViewModel.DGSample(DG);
            DataContext = _ViewModel;

        }

        /// <summary>
        /// TextBox.PreviewDragOver
        /// DataGrid.PreviewDragOver
        /// </summary>
        private void CsvFile_PreviewDragOver(object sender, System.Windows.DragEventArgs e)
        {

            // ファイルドロップかチェック
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                // ファイル形式ならコピー形式でドロップ
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                // 他形式はキャンセル
                e.Effects = DragDropEffects.None;
            }

            // 操作キャンセル
            e.Handled = true;

        }

        /// <summary>
        /// TextBox.Drop
        /// DataGrid.Drop
        /// </summary>
        private void CsvFile_Drop(object sender, System.Windows.DragEventArgs e)
        {

            bool isOK = false;

            // 複数ファイルを考慮してファイルパスを取得
            if (e.Data.GetData(DataFormats.FileDrop) is string[] files)
            {

                // 先頭CSVファイルを正とする
                foreach (string file in files)
                {

                    if (file.ToUpper().Contains(".XLSX"))
                    {
                        _ViewModel.ExcelPath = file;
                        isOK = true;
                        break;
                    }

                }

                if (!isOK)
                {
                    MessageBox.Show("xlsxファイルを指定してください", "Excel読込", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

        }

    }
}
