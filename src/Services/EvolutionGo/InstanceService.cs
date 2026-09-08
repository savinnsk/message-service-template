using Domain.Dtos;
using Domain.Records;
using Infra.EvolutionGo;

namespace Services.EvolutionGo.Instance;


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
    
    public Task<Result<string>> Disconnect(string instanceToken)
    {
        
        return _evolutionGoIntegration.Disconnect(instanceToken);
    } 
    
    
    public Task<Result<string>> GetAll()
    {
        
        return _evolutionGoIntegration.GetAll();
    } 
    
    public Task<Result<string>> Get(string instanceId)
    {
        
        return _evolutionGoIntegration.Get(instanceId);
    } 
}