using NeonSugar.Sandbox.Wallet.Interfaces;
using Math = NeonSugar.Sandbox.Utils.Math;

namespace NeonSugar.Sandbox.Wallet;

public static class DepositTransferer
{
	public static bool TryTransferAll(IDepositSource sender, IDepositSource receiver)
		=> TryTransfer(sender, receiver, sender.Deposit);

	public static bool TryTransfer(IDepositSource sender, IDepositSource receiver, int deposit)
	{
		deposit = Math.Min(sender.Deposit, receiver.DepositLeftSpace, deposit);
		
		if (sender.TryWithdraw(deposit) is false) return false;
		
		var deposited = receiver.TryDeposit(deposit);
		
		if (deposited != deposit)
			sender.TryDeposit(deposit - deposited);
		return true;
	}
}
