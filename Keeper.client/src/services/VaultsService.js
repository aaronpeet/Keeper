import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultsService {
  async getVaultKeeps(id) {
    const res = await api.get(`api/vaults/${id}/keeps`)
    AppState.activeVaultKeeps = res.data
  }
}

export const vaultsService = new VaultsService()
