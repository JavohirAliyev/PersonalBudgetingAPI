import { useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { AuthContext } from "../auth/AuthContext";
import http from "../api/http";

export default function Login() {
    const [isLogin, setIsLogin] = useState(true);
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [dateOfBirth, setDateOfBirth] = useState('');
    const [showPassword, setShowPassword] = useState(false);
    const [passwordConfirm, setPasswordConfirm] = useState('');
    const [errors, setErrors] = useState<{ [key: string]: string }>({});
    const [backendError, setBackendError] = useState('');
    const auth = useContext(AuthContext)!;
    const navigate = useNavigate();

    const validateLogin = () => {
        const errs: { [key: string]: string } = {};
        if (!email) errs.email = 'Email is required';
        if (!password) errs.password = 'Password is required';
        setErrors(errs);
        return Object.keys(errs).length === 0;
    };

    const validateRegister = () => {
        const errs: { [key: string]: string } = {};
        if (!firstName) errs.firstName = 'First name is required';
        if (!lastName) errs.lastName = 'Last name is required';
        if (!email) errs.email = 'Email is required';
        if (!password) errs.password = 'Password is required';
        if (!dateOfBirth) errs.dateOfBirth = 'Date of birth is required';
        if (password !== passwordConfirm) errs.passwordConfirm = 'Passwords do not match';
        setErrors(errs);
        return Object.keys(errs).length === 0;
    };

    const handleLogin = async () => {
        setBackendError('');
        if (!validateLogin()) return;
        try {
            const res = await http.post('/auth/login', { email, password });
            auth.login(res.data.token);
            navigate('/');
        } catch (err: any) {
            setBackendError(err.response?.data?.message || 'Login failed');
        }
    };

    const handleRegister = async () => {
        setBackendError('');
        if (!validateRegister()) return;
        try {
            await http.post('/auth/register', {
                firstName,
                lastName,
                email,
                password,
                dateOfBirth,
            });
            setShowPassword(false);
            setIsLogin(true);
        } catch (err: any) {
            setBackendError(err.response?.data?.message || 'Registration failed');
        }
    };

    return (
        <div className="min-h-screen flex items-center justify-center bg-gradient-to-br from-blue-100 via-white to-green-100">
            <div className="bg-white shadow-2xl rounded-3xl px-10 py-12 w-full max-w-md border border-gray-100">
                <div className="flex flex-col items-center mb-8">
                    <svg width="48" height="48" fill="none" viewBox="0 0 24 24" className="mb-2 text-blue-500">
                        <circle cx="12" cy="12" r="10" stroke="currentColor" strokeWidth="2" />
                        <path d="M8 15c1.333-1 4.667-1 6 0" stroke="currentColor" strokeWidth="2" strokeLinecap="round" />
                        <circle cx="9" cy="10" r="1" fill="currentColor" />
                        <circle cx="15" cy="10" r="1" fill="currentColor" />
                    </svg>
                    <h2 className="text-3xl font-bold text-gray-800">{isLogin ? 'Welcome Back' : 'Create Account'}</h2>
                    <p className="text-gray-500 mt-2">{isLogin ? 'Login to your account' : 'Register to get started'}</p>
                </div>
                {backendError && (
                    <div className="bg-red-50 border border-red-200 text-red-600 rounded px-4 py-2 mb-4 text-center">
                        {backendError}
                    </div>
                )}
                <form
                    onSubmit={e => {
                        e.preventDefault();
                        isLogin ? handleLogin() : handleRegister();
                    }}
                    className="space-y-5"
                >
                    {!isLogin && (
                        <>
                            <div>
                                <label className="block text-gray-700 mb-1 font-medium">First Name</label>
                                <input
                                    type="text"
                                    className={`w-full px-4 py-2 border ${errors.firstName ? 'border-red-400' : 'border-gray-200'} rounded-lg focus:ring-2 focus:ring-blue-200 outline-none transition`}
                                    value={firstName}
                                    onChange={(e) => setFirstName(e.target.value)}
                                    placeholder="First Name"
                                    autoComplete="given-name"
                                />
                                {errors.firstName && <div className="text-red-500 text-sm mt-1">{errors.firstName}</div>}
                            </div>
                            <div>
                                <label className="block text-gray-700 mb-1 font-medium">Last Name</label>
                                <input
                                    type="text"
                                    className={`w-full px-4 py-2 border ${errors.lastName ? 'border-red-400' : 'border-gray-200'} rounded-lg focus:ring-2 focus:ring-blue-200 outline-none transition`}
                                    value={lastName}
                                    onChange={(e) => setLastName(e.target.value)}
                                    placeholder="Last Name"
                                    autoComplete="family-name"
                                />
                                {errors.lastName && <div className="text-red-500 text-sm mt-1">{errors.lastName}</div>}
                            </div>
                            <div>
                                <label className="block text-gray-700 mb-1 font-medium">Date of Birth</label>
                                <input
                                    type="date"
                                    className={`w-full px-4 py-2 border ${errors.dateOfBirth ? 'border-red-400' : 'border-gray-200'} rounded-lg focus:ring-2 focus:ring-blue-200 outline-none transition`}
                                    value={dateOfBirth}
                                    onChange={(e) => setDateOfBirth(e.target.value)}
                                    autoComplete="bday"
                                />
                                {errors.dateOfBirth && <div className="text-red-500 text-sm mt-1">{errors.dateOfBirth}</div>}
                            </div>
                        </>
                    )}
                    <div>
                        <label className="block text-gray-700 mb-1 font-medium">Email</label>
                        <input
                            type="email"
                            className={`w-full px-4 py-2 border ${errors.email ? 'border-red-400' : 'border-gray-200'} rounded-lg focus:ring-2 focus:ring-blue-200 outline-none transition`}
                            value={email}
                            onChange={(e) => setEmail(e.target.value)}
                            placeholder="you@email.com"
                            autoComplete="email"
                        />
                        {errors.email && <div className="text-red-500 text-sm mt-1">{errors.email}</div>}
                    </div>
                    <div>
                        <label className="block text-gray-700 mb-1 font-medium">Password</label>
                        <div className="relative">
                            <input
                                type={showPassword ? "text" : "password"}
                                className={`w-full px-4 py-2 border ${errors.password ? 'border-red-400' : 'border-gray-200'} rounded-lg focus:ring-2 focus:ring-blue-200 outline-none transition`}
                                value={password}
                                onChange={(e) => setPassword(e.target.value)}
                                placeholder="Password"
                                autoComplete={isLogin ? "current-password" : "new-password"}
                            />
                            <button
                                type="button"
                                className="absolute right-3 top-1/2 -translate-y-1/2 text-gray-500"
                                tabIndex={-1}
                                onClick={() => setShowPassword((v) => !v)}
                            >
                                {showPassword ? 'Hide' : 'Show'}
                            </button>
                        </div>
                        {errors.password && <div className="text-red-500 text-sm mt-1">{errors.password}</div>}
                    </div>
                    {!isLogin && (
                    <div>
                        <label className="block text-gray-700 mb-1 font-medium">Confirm Password</label>
                        <div className="relative">
                            <input
                                type={showPassword ? "text" : "password"}
                                className={`w-full px-4 py-2 border ${errors.passwordConfirm ? 'border-red-400' : 'border-gray-200'} rounded-lg focus:ring-2 focus:ring-blue-200 outline-none transition`}
                                value={passwordConfirm}
                                onChange={(e) => setPasswordConfirm(e.target.value)}
                                placeholder="Confirm Password"
                                autoComplete="new-password"
                            />
                            <button
                                type="button"
                                className="absolute right-3 top-1/2 -translate-y-1/2 text-gray-500"
                                tabIndex={-1}
                                onClick={() => setShowPassword((v) => !v)}
                            >
                                {showPassword ? 'Hide' : 'Show'}
                            </button>
                        </div>
                        {errors.passwordConfirm && <div className="text-red-500 text-sm mt-1">{errors.passwordConfirm}</div>}
                    </div>
                    )}
                    <button
                        type="submit"
                        className={`w-full py-3 rounded-lg font-semibold shadow transition 
                            ${isLogin
                                ? "bg-blue-500 hover:bg-blue-600 text-white"
                                : "bg-green-500 hover:bg-green-600 text-white"
                            }`}
                    >
                        {isLogin ? "Login" : "Register"}
                    </button>
                </form>
                <div className="flex items-center my-6">
                    <div className="flex-grow border-t border-gray-200"></div>
                    <span className="mx-3 text-gray-400 text-sm">or</span>
                    <div className="flex-grow border-t border-gray-200"></div>
                </div>
                <button
                    onClick={() => {
                        setIsLogin((prev) => !prev);
                        setErrors({});
                        setBackendError('');
                    }}
                    className="w-full py-2 rounded-lg border border-blue-200 text-blue-600 font-medium hover:bg-blue-50 transition"
                >
                    {isLogin ? "Don't have an account? Register" : 'Already have an account? Login'}
                </button>
            </div>
        </div>
    );
}
