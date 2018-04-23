using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using DevExpress.XtraVerticalGrid.ViewInfo;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraEditors.DXErrorProvider;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {

       
        public Form1()
        {
            InitializeComponent();
        }

        private BaseRowViewInfo GetRowInfo(CustomDrawRowValueCellEventArgs e)
        {
            ArrayList rowsViewInfo = propertyGridControl1.ViewInfo.RowsViewInfo;
            for (int i = 0; i < rowsViewInfo.Count; i++)
            {
                BaseRowViewInfo info = rowsViewInfo[i] as BaseRowViewInfo;
                if (info.Row == e.Row)
                    return info;
            }
            return null;
        }

        public BaseEditViewInfo GetEditorViewInfo(BaseRowViewInfo rowInfo, CustomDrawRowValueCellEventArgs e)
        {
            if (rowInfo == null) return null;
            for (int i = 0; i < rowInfo.ValuesInfo.Count; i++)
            {
                RowValueInfo valuesInfo = rowInfo.ValuesInfo[i];
                if (valuesInfo.RecordIndex == e.RecordIndex && valuesInfo.RowCellIndex == e.CellIndex)
                    return valuesInfo.EditorViewInfo;
            }
            return null;
        }

        private void propertyGridControl1_CustomDrawRowValueCell(object sender, CustomDrawRowValueCellEventArgs e)
        {
            if (e.CellValue != null) return;
            BaseRowViewInfo rowInfo = GetRowInfo(e);
            BaseEditViewInfo editViewInfo = GetEditorViewInfo(rowInfo, e);
            editViewInfo.ErrorIconText = "IsNull";
            editViewInfo.ShowErrorIcon = true;
            editViewInfo.FillBackground = true;
            editViewInfo.ErrorIcon = DXErrorProvider.GetErrorIconInternal(ErrorType.Critical);
            editViewInfo.CalcViewInfo(e.Graphics);
        }



    }
}