import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaultKeeps(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.activeVaultKeeps = res.data
  }

  async createVault(newVault) {
    const res = await api.post('api/vaults', newVault)
    AppState.activeVaults.push(res.data)
  }

  async deleteVault(id) {
    await api.delete('api/vaults/' + id)
    AppState.activeVaults = AppState.activeVaults.filter(v => v.id !== id)
  }
}

export const vaultsService = new VaultsService()
