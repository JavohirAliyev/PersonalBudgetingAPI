import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from '../pages/Login';
import Dashboard from '../pages/Dashboard';
import Budgets from '../pages/Budgets';

const AppRoutes = () => (
    <BrowserRouter>
        <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/" element={<Dashboard />} />
            <Route path="/budgets" element={<Budgets />} />
        </Routes>
    </BrowserRouter>
);

export default AppRoutes;
