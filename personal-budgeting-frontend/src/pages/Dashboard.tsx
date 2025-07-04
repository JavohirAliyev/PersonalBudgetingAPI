import React from 'react';

const mockData = {
    balance: 3200,
    income: 4500,
    expenses: 1300,
    recentTransactions: [
        { id: 1, description: 'Groceries', amount: -120, date: '2024-06-10' },
        { id: 2, description: 'Salary', amount: 3000, date: '2024-06-08' },
        { id: 3, description: 'Electricity Bill', amount: -60, date: '2024-06-05' },
        { id: 4, description: 'Dining Out', amount: -45, date: '2024-06-03' },
    ],
};

const Dashboard: React.FC = () => {
    return (
        <div style={{ maxWidth: 800, margin: '0 auto', padding: 24 }}>
            <h1>Dashboard</h1>
            <div style={{ display: 'flex', gap: 24, marginBottom: 32 }}>
                <SummaryCard label="Balance" value={`$${mockData.balance}`} />
                <SummaryCard label="Income" value={`$${mockData.income}`} />
                <SummaryCard label="Expenses" value={`$${mockData.expenses}`} />
            </div>
            <h2>Recent Transactions</h2>
            <table style={{ width: '100%', borderCollapse: 'collapse' }}>
                <thead>
                    <tr>
                        <th style={{ textAlign: 'left', padding: 8 }}>Date</th>
                        <th style={{ textAlign: 'left', padding: 8 }}>Description</th>
                        <th style={{ textAlign: 'right', padding: 8 }}>Amount</th>
                    </tr>
                </thead>
                <tbody>
                    {mockData.recentTransactions.map(tx => (
                        <tr key={tx.id}>
                            <td style={{ padding: 8 }}>{tx.date}</td>
                            <td style={{ padding: 8 }}>{tx.description}</td>
                            <td style={{ padding: 8, textAlign: 'right', color: tx.amount < 0 ? 'red' : 'green' }}>
                                {tx.amount < 0 ? '-' : '+'}${Math.abs(tx.amount)}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
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