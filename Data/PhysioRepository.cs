using FisioSolution.Models;
using System.Text.Json;

namespace FisioSolution.Data;

public class PhysioRepository : IPhysioRepository
{
    private Dictionary<string, Physio> _physios = new Dictionary<string, Physio>();
    private readonly string _filePath = "physios.json";

    public void AddPhysio(Physio physio)
    {
        // Leer el contenido actual del archivo JSON, si existe
        string jsonString = File.Exists(_filePath) ? File.ReadAllText(_filePath) : "[]";

        // Deserializar el contenido en una lista de objetos Physio
        List<Physio> physios = JsonSerializer.Deserialize<List<Physio>>(jsonString);

        // Agregar el nuevo physio a la lista
        physios.Add(physio);

        try
        {
            // Serializar la lista actualizada en formato JSON con formato
            var options = new JsonSerializerOptions { WriteIndented = true };
            jsonString = JsonSerializer.Serialize(physios, options);

            // Escribir el JSON actualizado en el archivo
            File.WriteAllText(_filePath, jsonString);
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al guardar cambios en el archivo de usuarios", e);
        }
    }

}
