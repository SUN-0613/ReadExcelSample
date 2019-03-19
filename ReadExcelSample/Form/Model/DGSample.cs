using ClosedXML.Excel;
using System;
using System.Collections.Generic;

namespace ReadExcelSample.Form.Model
{

    /// <summary>
    /// DGSample.Model
    /// </summary>
    public class DGSample : IDisposable
    {

        /// <summary>
        /// DGSample.Model
        /// </summary>
        public DGSample()
        {

        }

        /// <summary>
        /// 終了処理
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// 引数指定EXCELファイル読込、Listに出力
        /// </summary>
        /// <param name="filePath">EXCELファイル(xlsx)</param>
        /// <returns>
        /// EXCEL本文内容
        /// 親List:行情報
        /// 子List:列情報
        /// </returns>
        /// <remarks>
        /// Copyright(c) 2016 ClosedXML
        /// Released under the MIT license
        /// https://github.com/ClosedXML/ClosedXML/blob/master/LICENSE
        /// </remarks>
        public List<List<string>> ReadExcel(string filePath)
        {

            var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet(1);
            var lastRow = worksheet.LastRowUsed().RowNumber();
            int lastColumn = worksheet.LastColumnUsed().ColumnNumber();
            var returnValues = new List<List<string>>();

            for (int iLoop = 1; iLoop <= lastRow; iLoop++)
            {

                returnValues.Add(new List<string>());

                for (int jLoop = 1; jLoop <= lastColumn; jLoop++)
                {
                    returnValues[iLoop - 1].Add(worksheet.Cell(iLoop, jLoop).Value.ToString());
                }

            }

            return returnValues;

        }

    }

}
