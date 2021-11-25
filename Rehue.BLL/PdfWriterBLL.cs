using iTextSharp.text;
using iTextSharp.text.pdf;
using Rehue.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehue.BLL
{
    public class PdfWriterBLL
    {
        public void CrearPDFCita(ICita cita)
        {
            string path = @"C:\Rehue";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            FileStream fs = new FileStream(path + @"\Cita_" + DateTime.Now.ToString("ddMMyyyyhhmm") + ".pdf", FileMode.Create);

            Document document = new Document(PageSize.A4, 25, 25, 30, 30);

            PdfWriter writer = PdfWriter.GetInstance(document, fs);

            document.AddAuthor("Mariano Veloso");
            document.AddCreator("Rehue Diploma using iTextSharp");

            document.Open();
            string titulo = "Pendiernte confirmación";

            document.Add(new Paragraph("Detalle de la cita"));
            document.Add(new Paragraph("Fecha creación: " + cita.FechaCreacion));
            document.Add(new Paragraph("Usuario que la creó: " + cita.Persona.ObtenerNombre()));
            document.Add(new Paragraph("Establecimiento: " + cita.Mesa.Empresa.ObtenerNombre()));
            document.Add(new Paragraph("Mesa: " + cita.Mesa.Descripcion));
            document.Add(new Paragraph("Cantidad de comensales: " + cita.Mesa.CantidadComensales));
            document.Add(new Paragraph("Fecha de encuentro: " + cita.FechaEncuentro));

            if (cita.FechaConfirmacion.HasValue)
            {
                document.Add(new Paragraph("Fecha confirmación: " + cita.FechaConfirmacion.Value));
                titulo = "Confirmada";
            }
            if (cita.FechaCancelacion.HasValue)
            {
                document.Add(new Paragraph("Fecha cancelación: " + cita.FechaCancelacion.Value));
                titulo = "Cancelada";
            }

            if (cita.Denuncia.Id != 0)
            {
                document.Add(new Paragraph("Fecha de denuncia: " + cita.Denuncia.FechaCancelacion.Value));
                document.Add(new Paragraph("Detalle de Denuncia: " + cita.Denuncia.Descripcion));
                titulo = "Denunciada";
            }

            document.Add(new Paragraph("Estado: " + titulo));
            document.Close();
            writer.Close();
            fs.Close();
        }
    }
}
