public interface IStateSwitcher<AS> {
    void SwitchState<S>() where S : AS;
}