using AutoMapper;
using DiploMate.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DiploMate.Tutor;

public class TutorController : ControllerBase
{
    private readonly IRepository<TutorDto> _repository;
    private readonly IMapper _mapper;
    
    public TutorController(IRepository<TutorDto> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tutorsDto = await _repository.GetListAsync();
        
        if (tutorsDto is null)
        {
            return NotFound();
        }
        
        IEnumerable<Tutor> tutors = _mapper.Map<IEnumerable<TutorDto>,IEnumerable<Tutor>>(tutorsDto);
        
        return Ok(tutors);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var tutorDto = await _repository.GetAsync(id);
        if (tutorDto is null)
        {
            return NotFound();
        }

        var tutor = _mapper.Map<Tutor>(tutorDto);
        return Ok(tutor);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Tutor tutor)
    {
        var tutorDto = _mapper.Map<TutorDto>(tutor);
        
        await _repository.UpdateAsync(id, tutorDto);
        return Ok();
    }
}