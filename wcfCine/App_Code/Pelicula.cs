using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Descripción breve de Pelicula
/// </summary>
/// 
[DataContract]
public class Pelicula
{
    [DataMember]
    public string PeliculaID;
    [DataMember]
    public string Nombre;
    [DataMember]
    public string Horarios;
    [DataMember]
    public string Clasificacion;
    [DataMember]
    public string Descripcion;
    [DataMember]
    public string Director;
    [DataMember]
    public string Actor;
    [DataMember]
    public string Duracion;
    [DataMember]
    public string Poster;//url 
    [DataMember]
    public string Trailer;//url
    [DataMember]
    public string Calificacion;


	public Pelicula()
	{
        PeliculaID = "";
        Nombre = "";
        Horarios = "";
        Clasificacion = "";
        Descripcion = "";
        Director = "";
        Actor = "";
        Duracion = "";
        Poster = "";
        Trailer = "";
        Calificacion = "";
	}
}