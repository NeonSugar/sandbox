namespace NeonSugar.Sandbox.Wallet.Interfaces;

public interface IDepositSource
{
	int MaxDeposit { get; }
	int Deposit    { get; }
	int DepositLeftSpace { get; }

	int TryDeposit(int deposit);
	protected internal bool TryWithdraw(int withdraw);
}
