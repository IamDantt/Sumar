using System;
using System.Collections.Generic;

[Serializable]
public class jsonData
{
    public string id_estudiante;
    public string nombre;
    public string apellido;
    public string descripcion;
    

    public List<ActividadesList> actividades;
}

[Serializable]
public class ActividadesList
{
    public string id_actividad;
    public string nombre;
    public string fecha_inicio;
    public string fecha_cierre;
    public string evaluada;
    public string disponibilidad;
    
    public List<string> preguntas;
    public List<string> respuestas;
    public List<string> opciones;
    public List<string> url_img;
}



