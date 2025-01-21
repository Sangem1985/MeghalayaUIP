using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MeghalayaAPI.DAL
{
    public class CommonDAL
    {
        #region ConvertToList

        public static List<ListDTO> ConvertToList<ListDTO>(List<DataRow> rows)
        {
            List<ListDTO> lst = null;
            try
            {
                if (rows != null)
                {
                    lst = new List<ListDTO>();
                    foreach (DataRow row in rows)
                    {
                        ListDTO item = CreateItem<ListDTO>(row);
                        lst.Add(item);
                    }
                }
                return lst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static ListDTO CreateItem<ListDTO>(DataRow row)
        {
            ListDTO obj = default(ListDTO);
            try
            {
                if (row != null)
                {
                    obj = Activator.CreateInstance<ListDTO>();
                    foreach (DataColumn column in row.Table.Columns)
                    {
                        FieldInfo prop = obj.GetType().GetField(column.ColumnName);
                        if (prop != null)
                        {
                            //PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                            try
                            {
                                object value = row[column.ColumnName];

                                if (value.ToString().Trim() != string.Empty)
                                {
                                    prop.SetValue(obj, value);
                                }
                            }
                            catch (Exception ex)
                            {
                                // WriteException(ex);
                                throw ex;
                            }
                        }
                        else
                        {
                            PropertyInfo objprop = obj.GetType().GetProperty(column.ColumnName);
                            if (objprop != null)
                            {
                                try
                                {
                                    object value = row[column.ColumnName];

                                    if (value.ToString().Trim() != string.Empty)
                                    {
                                        objprop.SetValue(obj, value, null);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // WriteException(ex);
                                    throw ex;
                                }
                            }
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            try
            {

                //Get all the properties
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in Props)
                {
                    //Defining type of data column gives proper data table 
                    var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                    //Setting column names as Property names
                    dataTable.Columns.Add(prop.Name, type);
                }
                foreach (T item in items)
                {
                    var values = new object[Props.Length];
                    for (int i = 0; i < Props.Length; i++)
                    {
                        //inserting property values to datatable rows
                        values[i] = Props[i].GetValue(item, null);
                    }
                    dataTable.Rows.Add(values);
                }

            }
            catch (Exception ex)
            {

            }

            //put a breakpoint here and check datatable
            return dataTable;
        }

        // List<string> countries = new List<string>();
        public static DataTable ListToDataTable<T>(IList<T> thisList, string Datacolumnname)
        {
            DataTable dt = new DataTable();
            if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
            {
                //DataColumn dc = new DataColumn("CountryList");
                DataColumn dc = new DataColumn(Datacolumnname);
                dt.Columns.Add(dc);

                foreach (T item in thisList)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = item;
                    dt.Rows.Add(dr);
                }
            }
            else
            {
                PropertyInfo[] propertyInfo = typeof(T).GetProperties();
                foreach (PropertyInfo pi in propertyInfo)
                {
                    DataColumn dc = new DataColumn(pi.Name, pi.PropertyType);
                    dt.Columns.Add(dc);
                }

                for (int item = 0; item < thisList.Count(); item++)
                {
                    DataRow dr = dt.NewRow();
                    for (int property = 0; property < propertyInfo.Length; property++)
                    {
                        dr[property] = propertyInfo[property].GetValue(thisList[item], null);
                    }
                    dt.Rows.Add(dr);
                }
            }
            dt.AcceptChanges();
            return dt;

        }
        #endregion

    }
}