import { BrowserRouter, Routes, Route } from 'react-router-dom';
import Login from '../pages/Login';
import Dashboard from '../pages/Dashboard';
import Budgets from '../pages/Budgets';
import Header from '../components/Header';

const AppRoutes = () => (
    <BrowserRouter future={{ v7_startTransition: true }}>
        <Header />
        <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/" element={<Dashboard />} />
            <Route path="/budgets" element={<Budgets />} />
        </Routes>
    </BrowserRouter>
);

export default AppRoutes;
