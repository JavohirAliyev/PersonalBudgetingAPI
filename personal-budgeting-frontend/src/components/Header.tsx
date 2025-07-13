import { useContext } from "react";
import { Link, useNavigate } from "react-router-dom";
import { AuthContext } from "../auth/AuthContext";

export default function Header() {
    const auth = useContext(AuthContext);
    const navigate = useNavigate();
    const isLoggedIn = !!auth?.user;

    const handleLogout = () => {
        auth?.logout();
        navigate("/login");
    };

    return (
        <header className="bg-indigo-100 shadow flex items-center justify-between px-6 py-4 mb-8">
            <div className="flex items-center gap-6">
                <Link to="/" className="text-2xl font-bold text-blue-600">BudgetApp</Link>
                {isLoggedIn && (
                    <nav className="flex gap-4">
                        <Link to="/" className="hover:text-blue-700">Dashboard</Link>
                        <Link to="/budgets" className="hover:text-blue-700">Budgets</Link>
                    </nav>
                )}
            </div>
            <div className="flex items-center gap-4">
                {isLoggedIn ? (
                    <>
                        <span className="text-gray-700 font-medium">{auth.user?.given_name} {auth.user?.family_name}</span>
                        <button onClick={handleLogout} className="bg-indigo-100 text-red-600 px-3 py-1 rounded hover:bg-red-200 transition">Logout</button>
                    </>
                ) : (
                    <Link to="/login" className="bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 transition">Login</Link>
                )}
            </div>
        </header>
    );
}
