import { AppState } from '../AppState'
import { api } from './AxiosService'

class ProfilesService {
  async getProfileKeeps(id) {
    const res = await api.get(`api/profiles/${id}/keeps`)
    AppState.activeKeeps = res.data
  }

  async getProfileVaults(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.activeVaults = res.data
  }
}

export const profilesService = new ProfilesService()
