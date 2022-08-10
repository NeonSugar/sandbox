using NeonSugar.Sandbox.Wallet.Interfaces;


namespace NeonSugar.Sandbox.Wallet;

public sealed class Wallet : IDepositSource
{
	#region Private Fields

	private int _maxDeposit;
	private int _deposit;

	#endregion

	#region Events

	public event Action<int>          Deposited;
	public event Action<int>          Withdrawed;
	public event Action<int>          DepositChanged;
	public event Action<IPurchaseble> Purchased;

	#endregion

	#region Private Properties

	private bool IsDepositAvailable
		=> _deposit < _maxDeposit;
	public int DepositLeftSpace
		=> _maxDeposit - _deposit;

	#endregion

	#region Public Properties

	public int MaxDeposit => _maxDeposit;
	public int Deposit => _deposit;

	#endregion

	#region Builder

	private Wallet (int maxDeposit, int deposit = 0) 
	{
		_maxDeposit = maxDeposit;
		_deposit    = deposit;
	}
	
	private Wallet (Wallet wallet) 
	{
		_maxDeposit = wallet._maxDeposit;
		_deposit    = wallet._deposit;
	}

	public static Wallet Create(int maxDeposit, int deposit = 0)
		=> new (maxDeposit, deposit);
	
	public static Wallet Create(Wallet wallet)
		=> new (wallet);

	#endregion

	#region Public Methods

	public bool IsEnoughToPurchase(IPurchaseble item)
		=> item.Cost <= _deposit;

	public int TryDeposit(int count) 
	{
		if (count <= 0) throw new ArgumentOutOfRangeException(
			paramName: nameof(count), message: "Increase value can't be below one.");
		
		count = Math.Min(count, DepositLeftSpace);
		_deposit += count;
		
		DepositChanged?.Invoke(_deposit);
		Deposited?.Invoke(count);
		
		return count;
	}

	public bool TryPurchase(IPurchaseble item) 
	{
		if (IsEnoughToPurchase(item) is false) return false;
		if (TryWithdraw(item.Cost) is false) return  false;
		
		Purchased?.Invoke(item);
		return true;
	}

	#endregion

	bool IDepositSource.TryWithdraw(int withdraw)
		=> TryWithdraw(withdraw);
	
	private bool TryWithdraw(int withdraw)
	{
		if (withdraw > _deposit) return false;

		_deposit -= withdraw;
		
		DepositChanged?.Invoke(_deposit);
		Withdrawed?.Invoke(withdraw);
		return true;
	}
}
