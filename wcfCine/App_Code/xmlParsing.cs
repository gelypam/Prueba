using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Xml;
using System.ServiceModel.Web;


/// <summary>
/// Descripción breve de xmlParsing
/// </summary>
public class xmlParsing 
{
    String strExpression;        
    XmlDocument doc;
    XmlNodeList Complejos_peli;
    XmlNodeList Complejos_hora;       
    XmlNode peliculaInfo;
    XmlNode complejoInfo;

    Cartelera cartel;
    Pelicula peli;

	public xmlParsing()
	{
		cartel = new Cartelera();        
        cartel.ComplejoID = 125;
        cartel.CiudadID = 51;
	}
    public xmlParsing(int ciudadID, int complejoID)
    {        
        cartel = new Cartelera();
        cartel.CiudadID = ciudadID;
        cartel.ComplejoID = complejoID;
    }
    
    public Cartelera getCartelCine()
    {        
        doc = new XmlDocument();
        try
        {
            doc.Load("http://www.cinepolis.com.mx/iphone/xml-iphone.aspx?query=cartelera&ci=" + cartel.CiudadID);
        }
        catch (Exception e) { return null; }

        try
        {
            complejoInfo = doc.SelectSingleNode("//Cartelera//Complejo[@Complejoid='" + cartel.ComplejoID + "']");
            cartel.Complejo = complejoInfo.Attributes.GetNamedItem("Nombre").Value;
            cartel.Latitud = complejoInfo.ChildNodes[1].InnerText.Trim();
            cartel.Longitud = complejoInfo.ChildNodes[2].InnerText.Trim();


            Complejos_peli = doc.SelectNodes("//Cartelera//Complejo[@Complejoid='" + cartel.ComplejoID + "']/Pelicula");
            foreach (XmlNode complejo_peli in Complejos_peli)
            {
                peli = new Pelicula();
                string Horario_Peli = "";
                peli.PeliculaID = complejo_peli.FirstChild.InnerText;

                Complejos_hora = doc.SelectNodes("//Cartelera//Complejo/Pelicula[Peliculaid='" + peli.PeliculaID + "']/Horarios/Horario");
                foreach (XmlNode horario in Complejos_hora)
                {
                    Horario_Peli += horario.InnerText + " - ";
                }

                peliculaInfo = doc.SelectSingleNode("//Peliculas//Pelicula[@Peliculaid='" + peli.PeliculaID + "']");

                peli.Nombre = peliculaInfo.Attributes.GetNamedItem("Nombre").Value;
                peli.Clasificacion = peliculaInfo.ChildNodes[1].InnerText;
                peli.Calificacion = peliculaInfo.ChildNodes[4].InnerText;
                peli.Descripcion = peliculaInfo.ChildNodes[6].InnerText;
                peli.Director = peliculaInfo.ChildNodes[7].InnerText;
                peli.Actor = peliculaInfo.ChildNodes[8].InnerText;
                peli.Duracion = peliculaInfo.ChildNodes[16].InnerText;
                peli.Trailer = peliculaInfo.ChildNodes[19].InnerText;
                peli.Horarios = Horario_Peli;

                cartel.Peliculas.Add(peli);

            }
        }
        catch (Exception e) { return null;}
        return cartel;
    }


}