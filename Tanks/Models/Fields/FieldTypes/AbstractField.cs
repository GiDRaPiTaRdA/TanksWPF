using PropertyChanged;

namespace Tanks.Models.Fields.FieldTypes
{
   [AddINotifyPropertyChangedInterface]
   public abstract class AbstractField
    {
        public FieldState? FieldPointState { get; }

        public Coordinates Coordinates { get; set; }

       protected AbstractField(Coordinates coordinates, FieldState? state)
        {
            this.Coordinates = coordinates;
            this.FieldPointState = state;
        }

       public virtual void Intercept(AbstractField field){}

        public override string ToString()
        {
            return this.Coordinates +" Field state: " + ((object)this.FieldPointState??"Null");
        }
    }
}
