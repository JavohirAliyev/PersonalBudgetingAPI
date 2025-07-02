import { useState, useContext } from 'react';
import http from '../api/http';
import { AuthContext } from '../auth/AuthContext';
import { useNavigate } from 'react-router-dom';

export default function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const auth = useContext(AuthContext)!;
    const navigate = useNavigate();

    const handleLogin = async () => {
        const res = await http.post('/auth/login', { email, password });
        auth.login(res.data.token);
        navigate('/');
    };

    return (
        <div className="p-8 max-w-md mx-auto">
            <h2 className="text-2xl mb-4">Login</h2>
            <input type="email" className="w-full mb-2" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Email" />
            <input type="password" className="w-full mb-4" value={password} onChange={(e) => setPassword(e.target.value)} placeholder="Password" />
            <button onClick={handleLogin} className="bg-blue-500 text-white px-4 py-2 rounded">Login</button>
        </div>
    );
}
