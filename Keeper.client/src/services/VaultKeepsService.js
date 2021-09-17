import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultKeepsService {
  async createVaultKeep(newVaultKeep) {
    const res = await api.post('api/vaultkeeps', newVaultKeep)
    AppState.vaultKeeps = res.data
  }

  async deleteVaultKeep(id) {
    await api.delete('api/vaultkeeps/' + id)
    AppState.activeVaultKeeps = AppState.activeVaultKeeps.filter(vk => vk.id !== id)
  }
}

export const vaultKeepsService = new VaultKeepsService()
