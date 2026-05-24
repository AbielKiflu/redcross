namespace AdaTranslation.Application.Features.Centers.Dtos
{
    public record CenterBaseDto(
         long Id,
         string Description,
         string Address,
         string Contact
    );
}
