import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';

// En desarrollo /api se redirige a la API .NET (dotnet run en src/SIGNET_Web.Api).
// El build se publica dentro de wwwroot de la API, que sirve la SPA.
export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    proxy: { '/api': 'http://localhost:5080' }
  },
  build: {
    outDir: '../src/SIGNET_Web.Api/wwwroot',
    emptyOutDir: true
  }
});
