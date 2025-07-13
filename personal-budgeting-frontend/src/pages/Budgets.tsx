import { useEffect, useState } from 'react';
import http from '../api/http';

export default function Budgets() {

    const [budgets, setBudgets] = useState<any[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState('');
    const [totalBudget, setTotalBudget] = useState(0);
    const [totalSpent, setTotalSpent] = useState(0);
    const [month] = useState(new Date().getMonth() + 1);
    const [year] = useState(new Date().getFullYear());

    useEffect(() => {
        setLoading(true);
        setError('');
        http.get(`/budgets?month=${month}&year=${year}`)
            .then(res => {
                setBudgets(res.data);
                setTotalBudget(res.data.reduce((sum: number, b: any) => sum + (b.budgetAmount || 0), 0));
                setTotalSpent(res.data.reduce((sum: number, b: any) => sum + (b.spentAmount || 0), 0));
            })
            .catch(err => {
                setError(err.response?.data?.message || 'Failed to load budgets');
            })
            .finally(() => setLoading(false));
    }, [month, year]);

    return (
        <div className="p-4 max-w-2xl mx-auto">
            <h2 className="text-2xl font-bold mb-4">Budgets for {month}/{year}</h2>
            {loading && <div className="text-gray-500">Loading budgets...</div>}
            {error && <div className="bg-red-100 text-red-700 px-4 py-2 rounded mb-4">{error}</div>}
            {!loading && !error && (
                <>
                    <div className="mb-6 flex gap-8">
                        <div className="bg-blue-50 rounded p-4 flex-1 text-center">
                            <div className="text-gray-500">Total Budgeted</div>
                            <div className="text-2xl font-bold text-blue-700">${totalBudget}</div>
                        </div>
                        <div className="bg-green-50 rounded p-4 flex-1 text-center">
                            <div className="text-gray-500">Total Spent</div>
                            <div className="text-2xl font-bold text-green-700">${totalSpent}</div>
                        </div>
                        <div className="bg-yellow-50 rounded p-4 flex-1 text-center">
                            <div className="text-gray-500">Remaining</div>
                            <div className="text-2xl font-bold text-yellow-700">${totalBudget - totalSpent}</div>
                        </div>
                    </div>
                    <table className="w-full border-collapse mb-6">
                        <thead>
                            <tr className="bg-gray-100">
                                <th className="p-2 text-left">Category</th>
                                <th className="p-2 text-right">Budgeted</th>
                                <th className="p-2 text-right">Spent</th>
                                <th className="p-2 text-right">Remaining</th>
                            </tr>
                        </thead>
                        <tbody>
                            {budgets.map((b: any) => (
                                <tr key={b.id} className="border-b">
                                    <td className="p-2">{b.categoryName}</td>
                                    <td className="p-2 text-right">${b.budgetAmount}</td>
                                    <td className="p-2 text-right text-red-600">${b.spentAmount ?? 0}</td>
                                    <td className="p-2 text-right text-green-700">${(b.budgetAmount ?? 0) - (b.spentAmount ?? 0)}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                    <div className="text-sm text-gray-500">Tip: Stay under your budget for each category to save more!</div>
                </>
            )}
        </div>
    );
}
