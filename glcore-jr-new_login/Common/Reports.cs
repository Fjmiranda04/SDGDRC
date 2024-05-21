using ClosedXML.Excel;
using GeneralLedger.SelfServiceCore.Data.DTOs;
using System.IO;

namespace Common
{
    public class Reports
    {
        public static byte[] GetReportPQRSFToExcel(PQRSFReportDTO pqrsf)
        {
            XLWorkbook newBookExcel = new XLWorkbook();
            var sheet = newBookExcel.Worksheets.Add("PQRSF");

            var CurrentRow = 2;

            #region GeneralInfo

            sheet.Cell(CurrentRow, 1).Value = "General Ledger";
            sheet.Cell(CurrentRow, 1).Style.Font.Bold = true;
            CurrentRow++;
            sheet.Cell(CurrentRow, 1).Value = "NIT 000000000";
            sheet.Cell(CurrentRow, 1).Style.Font.Bold = true;
            CurrentRow++;
            sheet.Cell(CurrentRow, 1).Value = "Matriz PQRSF";
            sheet.Cell(CurrentRow, 1).Style.Font.Bold = true;

            #endregion GeneralInfo

            CurrentRow++;
            CurrentRow++;

            #region HeaderExcel

            sheet.Cell(CurrentRow, 1).Value = "Número";
            sheet.Cell(CurrentRow, 2).Value = "Fecha";
            sheet.Cell(CurrentRow, 3).Value = "Tipo";
            sheet.Cell(CurrentRow, 4).Value = "Tipo Reseña";
            sheet.Cell(CurrentRow, 5).Value = "Estado";
            sheet.Cell(CurrentRow, 6).Value = "Cliente";
            sheet.Cell(CurrentRow, 7).Value = "Contacto Cliente";
            sheet.Cell(CurrentRow, 8).Value = "Recibido Por";
            sheet.Cell(CurrentRow, 9).Value = "Proceso Responsable";
            sheet.Cell(CurrentRow, 10).Value = "Descripción";
            sheet.Cell(CurrentRow, 11).Value = "Fecha de Cierre";
            sheet.Cell(CurrentRow, 12).Value = "Etiquetas";

            #endregion HeaderExcel

            CurrentRow++;

            #region BodyExcel

            sheet.Cell(CurrentRow, 1).Value = pqrsf.Id;
            sheet.Cell(CurrentRow, 2).Value = pqrsf.Fecha;
            sheet.Cell(CurrentRow, 3).Value = pqrsf.Tipo;
            sheet.Cell(CurrentRow, 4).Value = pqrsf.TipoSituacion;
            sheet.Cell(CurrentRow, 5).Value = pqrsf.Estado;
            sheet.Cell(CurrentRow, 6).Value = pqrsf.NombreCliente;
            sheet.Cell(CurrentRow, 7).Value = pqrsf.NombreContacto;
            sheet.Cell(CurrentRow, 8).Value = pqrsf.AgenteResposable;
            sheet.Cell(CurrentRow, 9).Value = pqrsf.Proceso;
            sheet.Cell(CurrentRow, 10).Value = pqrsf.Descripcion;
            sheet.Cell(CurrentRow, 11).Value = pqrsf.FechaCierre;
            sheet.Cell(CurrentRow, 12).Value = pqrsf.Etiquetas;

            #endregion BodyExcel

            var header = sheet.Range("A6:L6");
            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            header.Style.Font.Bold = true;
            header.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            header.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            header.Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            var body = sheet.Range("A7:L7");
            body.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            body.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            body.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            body.Style.Border.LeftBorder = XLBorderStyleValues.Thin;

            sheet.ColumnsUsed().AdjustToContents();

            var stream = new MemoryStream();
            newBookExcel.SaveAs(stream);
            var content = stream.ToArray();

            return content;
        }
    }
}