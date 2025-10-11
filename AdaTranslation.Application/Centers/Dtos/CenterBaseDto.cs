namespace AdaTranslation.Application.Centers.Dtos
{
    public record CenterBaseDto(
         long Id,
         string Description,
         string Address,
         string Contact
    );
}
