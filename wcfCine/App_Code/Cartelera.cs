using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de Cartelera
/// </summary>

[DataContract]
public class Cartelera
{    
    [DataMember]
    public int CiudadID;
    [DataMember]
    public string Ciudad;
    [DataMember]
    public int ComplejoID;
    [DataMember]
    public string Complejo;
    [DataMember]
    public string Latitud;
    [DataMember]
    public string Longitud;
    [DataMember]
    public List<Pelicula> Peliculas;

	public Cartelera()
	{
        CiudadID = 0;
        Ciudad = "";
        Complejo = "";
        Latitud = "";
        Longitud = "";
        Peliculas = new List<Pelicula>();
	}
}