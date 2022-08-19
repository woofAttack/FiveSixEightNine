public interface IComponentable<T> where T: IComponentable
{
    void Action();
}
public interface IComponentable { }

public interface IComponentSelectable : IComponentable { }
public interface IComponentUnselectable : IComponentable { }
public interface IComponentTrueable : IComponentable { }
public interface IComponentFalseable : IComponentable { }
public interface IComponentStartAnimation : IComponentable { }
public interface IComponentStopAnimation : IComponentable { }
