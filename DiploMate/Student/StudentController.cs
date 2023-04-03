using AutoMapper;
using DiploMate.DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiploMate.Student;


[Route("api/student")]
[ApiController]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IRepository<StudentDto> _repository;
    private readonly IMapper _mapper;

    public StudentController(IRepository<StudentDto> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var studentsDto = await _repository.GetListAsync();
        
        if (studentsDto is null)
        {
            return NotFound();
        }
        
        IEnumerable<Student> students = _mapper.Map<IEnumerable<StudentDto>,IEnumerable<Student>>(studentsDto);
        
        return Ok(students);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var studentDto = await _repository.GetAsync(id);
        if (studentDto is null)
        {
            return NotFound();
        }

        var student = _mapper.Map<Student>(studentDto);
        return Ok(student);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Student student)
    {
        var studentDto = _mapper.Map<StudentDto>(student);
        
        var newGuid = await _repository.InsertAsync(studentDto);

        return Created($"api/student/{newGuid}", null);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] Student student)
    {
        var studentDto = _mapper.Map<StudentDto>(student);
        
        await _repository.UpdateAsync(id, studentDto);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _repository.DeleteAsync(id);
        return NoContent();
    }
    
}