import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getAllKeeps() {
    const res = await api.get('api/keeps')
    AppState.keeps = res.data
  }

  async createKeep(newKeep) {
    const res = await api.post('api/keeps', newKeep)
    AppState.activeKeeps.push(res.data)
  }

  async deleteKeep(id) {
    await api.delete('api/keeps/' + id)
    AppState.activeKeeps = AppState.activeKeeps.filter(k => k.id !== id)
  }

  async getKeepById(id) {
    const res = await api.get('api/keeps/' + id)
    AppState.activeKeep = res.data
  }
}

export const keepsService = new KeepsService()
