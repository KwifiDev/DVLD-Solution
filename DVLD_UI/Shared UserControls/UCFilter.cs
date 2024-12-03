using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DVLD_UI
{
    public partial class UCFilter : UserControl
    {
        private DataTable _dataTable;

        public UCFilter()
        {
            InitializeComponent();
            txtSearch.KeyPress += new KeyPressEventHandler(TxtSearch_KeyPress);
        }

        public void LinkFilterWithDataTable(ref DataTable dataTable)
        {
            _dataTable = dataTable;
            LoadColumnsOnComboBoxFilter();
            CountNumberOfRecords(_dataTable.Rows.Count);
        }

        private void CountNumberOfRecords(int rowsNumber)
        {
            lblCountRecords.Text = rowsNumber.ToString();
        }

        private void LoadColumnsOnComboBoxFilter()
        {
            cbFilter.Items.Clear();

            cbFilter.Items.Add("None");
            foreach (DataColumn column in _dataTable.Columns)
            {
                if (column.DataType.Name.StartsWith("Int") || column.DataType.Name.Contains("String") || column.DataType.Name.Contains("Bool"))
                    cbFilter.Items.Add(column.ColumnName);
            }

            cbFilter.SelectedIndex = 0;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterDataInTable((string)cbFilter.SelectedItem, txtSearch.Text.ToLower().Trim());
        }

        //private void FilterDataOnGridView(string columnName, string textSearch)
        //{
        //    int countVisibleRows = 0;
        //    try
        //    {
        //        CurrencyManager currencyManager = (CurrencyManager)BindingContext[_dgv.DataSource];
        //        currencyManager.SuspendBinding();

        //        foreach (DataGridViewRow row in _dgv.Rows)
        //        {
        //            string cellValue = row.Cells[columnName].Value.ToString().ToLower();

        //            if (row.Visible = cellValue.Contains(textSearch)) countVisibleRows++;
        //        }

        //        currencyManager.ResumeBinding();
        //    }
        //    catch { }

        //    CountNumberOfRecords(countVisibleRows);
        //}

        private void FilterDataInTable(string columnName, string textSearch)
        {
            if (textSearch == "")
            {
                _dataTable.DefaultView.RowFilter = "";
                lblCountRecords.Text = _dataTable.DefaultView.Count.ToString();
                return;
            }

            string columnType = _dataTable.Columns[columnName].DataType.Name;

            if (columnType.StartsWith("Int") || columnType.Contains("Bool"))
            {
                //in this case we deal with integer not string.
                _dataTable.DefaultView.RowFilter = string.Format("[{0}] = {1}", columnName, textSearch);
                lblCountRecords.Text = _dataTable.DefaultView.Count.ToString();
                return;
            }

            if (columnType.Contains("String"))
            {
                //in this case we deal with string not integer.
                _dataTable.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", columnName, textSearch);
                lblCountRecords.Text = _dataTable.DefaultView.Count.ToString();
                return;
            }
        }

        private void CbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = (string)cbFilter.SelectedItem;

            txtSearch.Text = default;
            cbIsActive.SelectedIndex = default;

            if (selectedItem == "None")
            {
                cbIsActive.Visible = false;
                txtSearch.Visible = false;
                FilterDataInTable(_dataTable.Columns[0].ColumnName, ""); // Show All Rows Data On Grid View
                return;
            }

            if (selectedItem.StartsWith("Is"))
            {
                txtSearch.Visible = false;
                cbIsActive.Visible = true;
                return;
            }

            if (!selectedItem.StartsWith("Is"))
            {
                cbIsActive.Visible = false;
                txtSearch.Visible = true;
                txtSearch.Focus();
                return;
            }
        }

        private void TxtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            string columnType = _dataTable.Columns[((string)cbFilter.SelectedItem)].DataType.Name;

            if (columnType.StartsWith("Int") && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = ((string)cbIsActive.SelectedItem) == "Yes" ? "true" : ((string)cbIsActive.SelectedItem) == "No" ? "false" : "";
            FilterDataInTable((string)cbFilter.SelectedItem, selectedValue.Trim());
        }

        internal void CalculateRecords(int rowCount)
        {
            CountNumberOfRecords(rowCount);
            txtSearch.Text = default;
        }
    }
}
