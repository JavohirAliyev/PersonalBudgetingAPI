import ReactDOM from 'react-dom/client';
import './index.css';
import AppRoutes from './routes/Routes';
import { AuthProvider } from './auth/AuthContext';

ReactDOM.createRoot(document.getElementById('root')!).render(
  <AuthProvider>
    <AppRoutes />
  </AuthProvider>
);
