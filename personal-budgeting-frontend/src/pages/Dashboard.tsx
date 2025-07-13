import React, { useEffect, useState } from 'react';
import http from '../api/http';

const mockData = {
    balance: 3200,
    income: 4500,
    expenses: 1300
};

interface Transaction {
    id: number;
    description: string;
    amount: number;
    date: Date;
    category: Category
};

interface TransactionDto {
    description: string;
    amount: number;
    date: Date;
    categoryId: number;
    budgetId: number;
    userId: number;
};

interface Category {
    id: number;
    name: string;
};

const Dashboard: React.FC = () => {
    const [transactions, setTransactions] = useState<Transaction[]>([]);
    const [showForm, setShowForm] = useState(false);
    const [newTransaction, setNewTransaction] = useState({
        description: '',
        amount: '',
        date: '',
    });

    useEffect(() => {
        http.get('/transactions/').then(response => {
            setTransactions(response.data);
        })
    }, []);

    const handleAddTransaction = () => {
        const { description, amount } = newTransaction;
        if (!description || !amount) return;

        const newTx: TransactionDto = {
            description,
            amount: parseFloat(amount),
            date: new Date(Date.now()),
            categoryId: 1,
            userId: 1,
            budgetId: 1
        };

        setTransactions(prev => [...prev,
        {
            amount: newTx.amount,
            date: newTx.date,
            description: newTx.description,
            category: { id: newTx.categoryId, name: "General" },
            id: Date.now()
        }]);
        http.post('/transactions', newTx);
        setNewTransaction({ description: '', amount: '', date: '' });
        setShowForm(false);
    };

    return (
        <div style={{ maxWidth: 800, margin: '0 auto', padding: 24 }}>
            <h1 className='text-xl'>Dashboard</h1>
            <div style={{ display: 'flex', gap: 24, marginBottom: 32 }}>
                <SummaryCard label="Balance" value={`$${mockData.balance}`} />
                <SummaryCard label="Income" value={`$${mockData.income}`} />
                <SummaryCard label="Expenses" value={`$${mockData.expenses}`} />
            </div>
            <h2 className='text-xl'>Recent Transactions</h2>
            <button
                onClick={() => setShowForm(!showForm)}
                className="mt-2 mb-4 px-4 py-2 bg-blue-500 text-white rounded hover:bg-blue-600"
            >
                {showForm ? 'Cancel' : 'New Transaction'}
            </button>

            {showForm && (
                <div className="mb-4 space-y-2">
                    <input
                        type="text"
                        placeholder="Description"
                        value={newTransaction.description}
                        onChange={(e) =>
                            setNewTransaction({ ...newTransaction, description: e.target.value })
                        }
                        className="block w-full border px-2 py-1"
                    />
                    <input
                        type="number"
                        placeholder="Amount"
                        value={newTransaction.amount}
                        onChange={(e) =>
                            setNewTransaction({ ...newTransaction, amount: e.target.value })
                        }
                        className="block w-full border px-2 py-1"
                    />
                    <button
                        onClick={handleAddTransaction}
                        className="px-4 py-2 bg-green-500 text-white rounded hover:bg-green-600"
                    >
                        Add Transaction
                    </button>
                </div>
            )}

            {transactions.length === 0 && <div className='text-center pt-4'>No transactions found.</div>}
            {transactions.length > 0 && (
                <table style={{ width: '100%', borderCollapse: 'collapse' }}>
                    <thead>
                        <tr>
                            <th style={{ textAlign: 'left', padding: 8 }}>Date</th>
                            <th style={{ textAlign: 'left', padding: 8 }}>Description</th>
                            <th style={{ textAlign: 'right', padding: 8 }}>Amount</th>
                        </tr>
                    </thead>
                    <tbody>
                        {transactions.map(tx => (
                            <tr key={tx.id}>
                                <td style={{ padding: 8 }}>{new Date(tx.date).toLocaleString()}</td>
                                <td style={{ padding: 8 }}>{tx.description}</td>
                                <td style={{ padding: 8, textAlign: 'right', color: tx.amount < 0 ? 'red' : 'green' }}>
                                    {tx.amount < 0 ? '-' : '+'}${Math.abs(tx.amount)}
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            )}
        </div>
    );
};

type SummaryCardProps = {
    label: string;
    value: string;
};

const SummaryCard: React.FC<SummaryCardProps> = ({ label, value }) => (
    <div style={{
        flex: 1,
        background: '#f5f5f5',
        borderRadius: 8,
        padding: 16,
        boxShadow: '0 2px 8px rgba(0,0,0,0.05)',
        textAlign: 'center'
    }}>
        <div style={{ fontSize: 18, color: '#888' }}>{label}</div>
        <div style={{ fontSize: 28, fontWeight: 700 }}>{value}</div>
    </div>
);

export default Dashboard;