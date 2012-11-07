using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
    
    [WebInvoke(Method = "GET", 
                   ResponseFormat = WebMessageFormat.Json,
                   RequestFormat = WebMessageFormat.Json,
                   UriTemplate = "cartelCine/{ciudad}/{complejo}")]
    public Cartelera GetCartelera(int ciudad, int complejo)
    {
        xmlParsing cine = new xmlParsing(ciudad, complejo);
        return cine.getCartelCine();
    }

    [WebGet(ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json,
            UriTemplate = "cartel/")]
    public Cartelera GetCarteleraNP()
    {
        xmlParsing cine = new xmlParsing();
        return cine.getCartelCine();
    }
}
