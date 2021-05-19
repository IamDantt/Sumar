using System;
using System.Collections.Generic;

[Serializable]
public class jsonData
{
    public string id_persona;
    public string puntuacion;
    public List<ActividadesList> actividades; 

}

[Serializable]
public class ActividadesList
{
    public string nombre;
    public string disponible;
    public string calificacion;
    public List<string> preguntas;
    public List<string> respuestas;
    public List<string> img;
}



