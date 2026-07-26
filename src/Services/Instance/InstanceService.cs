using System.Text.Json;
using Domain.Dtos;
using Domain.Records;
using message_service.Infra.EvolutionGo;

namespace message_service.Services;


public class InstanceService
{
    EvolutionGoIntegration _evolutionGoIntegration;
    
    public InstanceService(EvolutionGoIntegration evolutionGoIntegration)
    {
        _evolutionGoIntegration = evolutionGoIntegration;
    }
    public Task<Result<string>> CreateInstance(CreateInstanceDto dto)
    {

        var nameInstance = $"{dto.Name}_{Guid.NewGuid()}";
        
        var req = new CreateInstanceDto(
            Name : nameInstance,
            Token : nameInstance,
            AdvanceSettings: dto.AdvanceSettings
            );
        
        return _evolutionGoIntegration.CreateInstance(req);
    } 
    
    
    public Task<Result<string>> ConnectQr(string instanceName)
    {
        
        return _evolutionGoIntegration.ConnectQr(instanceName);
    } 
    
    public Task<Result<string>> GetStatus(string instanceName)
    {
        
        return _evolutionGoIntegration.GetStatus(instanceName);
    } 
    
    public Task<Result<string>> Delete(string instanceId)
    {
        
        return _evolutionGoIntegration.Delete(instanceId);
    } 
}