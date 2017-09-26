using LastMile.Web.Automation.BRDataTypes;
using LastMile.Web.Automation.BRBaseObjects;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;

namespace LastMile.Web.Automation.LMDMSPortal.LMBaseObjects
{
    public  class LMBaseData
    { 
    #region MemberVars
        string m_fileName = BRGlobalVars.SUPPORT_DIR + "Task_Data.xlsx";
    public WorkbookPart wbPart = null;
    public WorksheetPart wsPart = null;
    public SheetData sheetData = null;

    #endregion

    #region Properties

    #endregion

    #region Constructors

    //public LMBaseData(string fileName)
    //{
    //    m_fileName = fileName;
    //}
    #endregion
    #region Methods
    /// <summary>
    /// This method will return a dictionary variable with column name as the key 
    /// and test data specific for that column for the script as the value. Eg : [Business Unit,Brokerage][Service Type, TruckLoad Contract]...
    /// </summary> 
    public System.Collections.Generic.Dictionary<string, string> GetTestData(string sheetName, string scriptName)
    {
        DataRow columnNameRow = null;
        DataRow columnTestRow = null;
        string columnname, columnvalue;
        Dictionary<string, string> testData = new Dictionary<string, string>();
        DataTable dt = BROpenXMLHelper.ExcelWorksheetToDataTable(m_fileName, sheetName, scriptName);
        Console.WriteLine(dt.TableName);
        columnNameRow = dt.Rows[0];
        columnTestRow = dt.Rows[1];

        for (int i = 0; i < columnNameRow.Table.Columns.Count; i++)
        {
            columnname = columnNameRow[i].ToString();
            columnvalue = columnTestRow[i].ToString();
            testData.Add(columnname, columnvalue);
        }

        return testData;
    }
    private static readonly Regex ColumnNameRegex = new Regex("[A-Za-z]+");
    private static string GetColumnName(string cellReference)
    {
        if (ColumnNameRegex.IsMatch(cellReference))
            return ColumnNameRegex.Match(cellReference).Value;

        throw new ArgumentOutOfRangeException(cellReference);
    }
    #endregion
}
}
