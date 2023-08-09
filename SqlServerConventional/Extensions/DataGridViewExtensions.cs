using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SqlServerConventional.Extensions
{
    internal static class DataGridViewExtensions
    {
        /// <summary>
        /// Provides very fast and basic column sizing for large data sets.
        /// </summary>
        public static void FastAutoSizeColumns(this DataGridView targetGrid, params string[] includeColumns)
        {
            // Cast out a DataTable from the target grid data source.
            // We need to iterate through all the data in the grid and a DataTable supports enumeration.
            var gridTable = (DataTable)targetGrid.DataSource;

            // Create a graphics object from the target grid. Used for measuring text size.
            using (var gfx = targetGrid.CreateGraphics())
            {
                // Iterate through the columns.
                for (int index = 0; index < gridTable.Columns.Count; index++)
                {
                    var test = gridTable.Columns[index];
                    if (includeColumns.Contains(gridTable.Columns[index].ColumnName))
                    {
                        // Leverage Linq enumerator to rapidly collect all the rows into a string array, making sure to exclude null values.
                        string[] colStringCollection = gridTable.AsEnumerable().Where(r => r.Field<object>(index) != null).Select(r => r.Field<object>(index).ToString()).ToArray();

                        // Sort the string array by string lengths.
                        colStringCollection = colStringCollection.OrderBy((x) => x.Length).ToArray();

                        // Get the last and longest string in the array.
                        string longestColString = colStringCollection.Last();

                        // Use the graphics object to measure the string size.
                        var colWidth = gfx.MeasureString(longestColString, targetGrid.Font);

                        // If the calculated width is larger than the column header width, set the new column width.
                        if (colWidth.Width > targetGrid.Columns[index].HeaderCell.Size.Width)
                        {
                            targetGrid.Columns[index].Width = (int)colWidth.Width;
                        }
                        else // Otherwise, set the column width to the header width.
                        {
                            targetGrid.Columns[index].Width = targetGrid.Columns[index].HeaderCell.Size.Width;
                        }
                    }
                }
            }
        }
    }
}
