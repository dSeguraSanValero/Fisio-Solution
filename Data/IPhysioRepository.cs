using FisioSolution.Models;

namespace FisioSolution.Data;
public interface IPhysioRepository
{
    void AddPhysio(Physio physio);
}