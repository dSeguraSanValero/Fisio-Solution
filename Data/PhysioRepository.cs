using FisioSolution.Models;
using System.Text.Json;

namespace FisioSolution.Data;

public class PhysioRepository : IPhysioRepository
{
    private Dictionary<string, Physio> _physios = new Dictionary<string, Physio>();
    private readonly string _filePath = "../../../physios.json";

    public void AddPhysio(Physio physio)
    {
        _physios[physio.Id.ToString()] = physio;

        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_physios.Values, options);
            File.WriteAllText(_filePath, jsonString);
        }
        catch (Exception e)
        {
            throw new Exception("Ha ocurrido un error al guardar cambios en el archivo de usuarios", e);
        }
    }
}
