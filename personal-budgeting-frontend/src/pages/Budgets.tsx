import { useEffect, useState } from 'react';
import http from '../api/http';

export default function Budgets() {
    const [budgets, setBudgets] = useState([]);

    useEffect(() => {
        http.get('/budgets?month=7&year=2025').then(res => {
            setBudgets(res.data);
        });
    }, []);

    return (
        <div className="p-4">
            <h2 className="text-xl mb-4">Monthly Budgets</h2>
            <ul>
                {budgets.map((b: any) => (
                    <li key={b.id}>
                        {b.categoryName}: ${b.budgetAmount}
                    </li>
                ))}
            </ul>
        </div>
    );
}
