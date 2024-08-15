<template>
  <v-card>
    <v-sheet color="secondary">
      <v-row>
        <v-col>
          <v-card-title
            >{{ question.text }}
            <v-btn
              class="ml-2"
              variant="tonal"
              icon
              :to="{ name: 'question', params: { id: question.questionId } }"
            >
              <v-icon>fa-solid fa-pencil</v-icon>
            </v-btn>
          </v-card-title>
        </v-col>
        <v-col cols="auto" align="right">
          <v-card-title>
            <v-chip>{{ Category[question.category ?? 0] }}</v-chip>
          </v-card-title>
        </v-col>
      </v-row>
      <v-spacer />
    </v-sheet>

    <v-card-text>
      <v-chip
        @click="selectAnswer(answer)"
        v-for="answer in question.answers"
        :key="answer.answerId!"
        class="mx-1"
        :color="answerColor(answer)"
      >
        {{ answer.text }}
      </v-chip>
    </v-card-text>
  </v-card>
</template>

<script setup lang="ts">
import { Answer, Question, Category } from "@/models.g";

const props = defineProps<{
  question: Question;
}>();
const selectedAnswer = ref<Answer | null>(null);
function selectAnswer(answer: Answer) {
  selectedAnswer.value = answer;
}

function answerColor(answer: Answer) {
  if (selectedAnswer.value === null) {
    return "grey";
  }

  if (answer.answerId === props.question.correctAnswer?.answerId) {
    return "success";
  }

  if (selectedAnswer.value.answerId === answer.answerId) {
    return "error";
  }

  return "grey";
}
</script>
