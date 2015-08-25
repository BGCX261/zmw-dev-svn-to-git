using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Excel;

namespace CommonUtils.Tools
{
    public class Excel
    {
        private Application _excel;

        private Workbook _book;

        private Sheets _sheets;

        public Worksheet WorkSheet;

        public Range Range;

        /// <summary>
        /// 打開文件
        /// </summary>
        /// <param name="fileName"></param>
        public void OpenFile(string fileName)
        {
            _excel = new Application();

            _book = _excel.Workbooks.Open(fileName);

            _sheets = _book.Sheets;

            GetSheet(1);
        }

        #region 表單
        /// <summary>
        /// 選定表單
        /// </summary>
        /// <param name="item"></param>
        public void GetSheet(int item)
        {
            WorkSheet = _sheets.get_Item(item);
        }

        public void NewSheet(int count)
        {
            _sheets.Add(Type.Missing, Type.Missing, count);
        }
        #endregion

        #region 數據
        /// <summary>
        /// 數據取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="range"></param>
        /// <returns></returns>
        public T GetValue<T>(string range)
        {
            Range = WorkSheet.get_Range(range);

            return Range.Value;
        }

        /// <summary>
        /// 寫入
        /// </summary>
        /// <param name="range"></param>
        /// <param name="value"></param>
        public void SetValue(string range, object value)
        {
            Range = WorkSheet.get_Range(range);
            Range.Value = value;
        }

        public void SetValues(List<ExcelRangeValue> values)
        {
            foreach (ExcelRangeValue value in values)
            {
                SetValue(value.Range, value.Value);
            }
        }
        #endregion


        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            _book.Save();
        }


    }

    public class ExcelRangeValue
    {
        public string Range;
        public object Value;
    }
}
